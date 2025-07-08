flowchart TB
    subgraph "Client Side"
        Client["Vue.js SPA Client"]:::frontend
    end

    subgraph "Server Side"
        API["ASP.NET Core API"]:::api
        BLL["Business Logic Layer"]:::bll
        DAL["Data Access Layer"]:::dal
        Entities["Domain Entities"]:::entities
        Common["Common Utilities"]:::common
    end

    subgraph "Infrastructure"
        MySQL[(MySQL Database)]:::db
        Redis[(Redis Cache)]:::cache
        SQL["exchange.sql"]:::script
    end

    RedisUpdate["RedisUpdate Service"]:::service

    Client <-->|"HTTP/HTTPS"| API
    API -->|"Executes Services"| BLL
    BLL -->|"Uses Repositories"| DAL
    DAL -->|"CRUD Operations"| MySQL
    BLL -.->|"Cache Read/Write"| Redis
    DAL -.->|"Cache Read/Write"| Redis
    RedisUpdate -.->|"Refreshes Cache"| Redis
    API -->|"DI, Middleware, Helpers"| Common
    BLL -->|"Helpers, Settings"| Common
    DAL -->|"Helpers, Settings"| Common
    DAL -->|"Uses Models"| Entities
    BLL -->|"Uses Models"| Entities

    click Client "https://github.com/ahmadmdabit/exchange/tree/master/ui/"
    click API "https://github.com/ahmadmdabit/exchange/tree/master/API/"
    click BLL "https://github.com/ahmadmdabit/exchange/tree/master/BLL/"
    click DAL "https://github.com/ahmadmdabit/exchange/tree/master/DAL/"
    click Entities "https://github.com/ahmadmdabit/exchange/tree/master/Entities/"
    click Common "https://github.com/ahmadmdabit/exchange/tree/master/Common/"
    click RedisUpdate "https://github.com/ahmadmdabit/exchange/tree/master/RedisUpdate/"
    click SQL "https://github.com/ahmadmdabit/exchange/blob/master/exchange.sql"

    classDef frontend fill:#CEF,stroke:#036,stroke-width:1px
    classDef api fill:#FCF,stroke:#930,stroke-width:1px
    classDef bll fill:#CFC,stroke:#393,stroke-width:1px
    classDef dal fill:#CFF,stroke:#099,stroke-width:1px
    classDef entities fill:#FCC,stroke:#933,stroke-width:1px
    classDef common fill:#EEE,stroke:#666,stroke-width:1px
    classDef service fill:#FDC,stroke:#F90,stroke-width:1px
    classDef db fill:#CCF,stroke:#36F,stroke-width:1px
    classDef cache fill:#FFC,stroke:#F90,stroke-width:1px
    classDef script fill:#EEE,stroke:#333,stroke-width:1px