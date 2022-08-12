# This folder is specifically about the controllers (HttpRequests) #

1. For each unique requests we have controllers
2. For eg. ProductsController, UserController and so on

-> DbContext
 - We need to create a constructor and inject our DbContext into it
 - What it does is that it generates a new session and we can then get the values from DB to the specific controller and then we can then add different methods to manipulate those
 ```
  //Constructor
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }
 ```
- Use this _context to get data