<template>
  <div id="app">
    <h2>Vue.js WebSocket Exchange</h2> 
    <!-- <button v-on:click="sendMessage('hello')">Send Message</button> -->
    <hr>
    <vue-good-table :columns="cols" :rows="dataList"/>
  </div>
</template>

<script>
import 'vue-good-table/dist/vue-good-table.css'
import { VueGoodTable } from 'vue-good-table';

export default {
  name: 'Main',
  components: {
      VueGoodTable,
  },
  data: function() {
    return {
      connection: null,
      cols: [
      {
          label: 'Symbol',
          field: 'Symbol',
          filterOptions: { enabled: true, },    
        },
        {
          label: 'PurchasePrice',
          field: 'PurchasePrice',
          type: 'number',
        },
        {
          label: 'SalePrice',
          field: 'SalePrice',
          type: 'number',
        },
        {
          label: 'StepSize',
          field: 'StepSize',
          type: 'number',
        },
      ],
      dataList: []
    }
  },
  methods: {
    sendMessage: function(message) {
      console.log("Hello")
      console.log(this.connection);
      this.connection.send(message);
    }
  },
  created: function() {
    const that = this;

    console.log("Starting connection to WebSocket Server")
    this.connection = new WebSocket("wss://localhost:44390/ws")

    this.connection.onmessage = function (event)  {
      console.log(event);

      const reader = new FileReader();
      reader.addEventListener('loadend', () => {
        // reader.result contains the contents of blob as a typed array
        // console.warn(reader.result)
        const json = String.fromCharCode.apply(null, new Uint16Array(reader.result));
        let jsonObject = JSON.parse(json);
        if (typeof jsonObject == 'string') {
          jsonObject = JSON.parse(jsonObject);
        }
        that.dataList = jsonObject;
      });
      reader.readAsArrayBuffer(event.data);
    }

    this.connection.onopen = function(event) {
      console.log(event)
      console.log("Successfully connected to the echo websocket server...")
    }

    setInterval(()=> that.sendMessage(), 1000);
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>