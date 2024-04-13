# ASP.Net_Project_EcommerceApp - NYAB Not Your Average Bicep

## Project Description
- This ASP.Net Project is a Gym Product Ecommerce platform featuring REST APIs for managing products, carts, and orders, alongside a web-based UI client.
- This project adopts the Entity Framework Core Database First approach. Please refer to the Scheme file titled - NYAB_DB_Schema.
- The system allows users to browse products, add them to carts, and complete orders seamlessly.
- It is broken down to 4 Project namely; ProductsRestAPI, CartsRestsAPI, OrdersRestAPI, and UIWebApp projects.
- The Products API enables CRUD operations on products, while the Carts API handles cart management, including adding, removing, and clearing items, as well as checkout functionality. Orders are managed through a dedicated API, associating them with carts and customer names.
- The UI client provides an intuitive interface for users to interact with these services, ensuring data integrity and synchronization across the system.
- Overall, NYAB offers a streamlined and efficient shopping experience for both customers and administrators.

## Project Timeline
26 March 2024: Sprint1 Completion - App Fuctionality
- Project is completed locally but some adjustment needs to be done. Backend needs to clean up unnecessary items, while frontend currently uses off the shelf template provided.
- Current App Functionality:
  - BackEnd:
    - ProductRestApi
      - Create Product
      - Read All Product
      - Read a single product by Id
      - Read a single product by Name
      - Update a single product by Id
      - Delete a single product by Id
    - CartsRestApi
      - Create Cart
      - Read all cart
      - Read Single cart by Id
      - Update add product (productId) to cart (cartId)
      - Update remove product (productId) from cart (cartId)
      - update remove all products from cart (cartId)
      - Delete cart by cartId
    - OrdersRestApi
      - Create Order
      - Read single order by Id
  - FrontEnd:
    - Index
      - Create Shopping Cart: To create a cart for the user
        - Cart View: Once cart created, it will bring User to View Cart Page with Total Price of products and List of Products
        - All Products View
      - All Products View: To view all Products
        - Cart View
        - Search Engine for product items by Name
        - List of each product name
          - Single Product View: View the Product Id, Product Name, Price, and option to add it to cart
            - Add to Cart
            - Return to View All Product View
- Once cleaning is complete, we will host this App on Somee.com 
- In Phase2, we will focus on enhancing the frontend design.

3 - 6 April 2024 : Code Cleaning
- Identified certain areas for enhancement consideration
  1. Index page display 2 links: Get a shopping cart! and All Products link
     - Look to upgrade the display - Maybe change it into icon/ nav bar display
  2. All Products link currently display all product details.
     - Change the display of full info in OneProduct View.
     - Add return to main index page
  3. OneProduct View page
     - Add return to AllProducts view page
  5. Consider using AutoMapper to map the Model constructs from REST API to MVC. Currently is manual import over.
  6. Optional: Utilize different serializer. Eg. builder.Services.AddControllersWithViews().AddXmlSerializerFormatters();
  7. Look into Customized exception handling.
  8. Currently, to display all product items in a cart, it is used through DTO concept in REST API. To reevaluate if using a ModelView approach is more beneficial and practical.
     - Same goes for couple of other methods within Carts Controller. Since currently Cart Controller dependency inject both product and cart context, there is no clear
       separation of concern. Decoupling them would be more suitable.
     - Another approach is to utilize Event-driven architecture
  9. Consider Remodel to microservices architecture, but probably at a later stage. May need to work on upskilling a course.
  10. Create a ReadMe for each Project component
  11. Currently DeleteProductFromCartAsync() method from CartClient deletes all of provided productId from the cart. To change it to delete one of the product item from Cart
  12. Allow to add multiple quantity of one product (Completed - Refer to Commit History for further enhancement complications)
 
  7 - 8 April 2024 : Enhancement
  12. Allow to add multiple quantity of one product (Completed - Refer to Commit History for further enhancement complications)
  7. Look into Customized exception handling (WIP. Compelted for CartController, CartClient, UiController)

  11-12 April 2024 : Enhancement
  - All Products link currently display all product details.
  - Change the display of full info in OneProduct View.
  - Add return to main index page
  - OneProduct View page 
  - Add return to AllProducts view page
  - Added images, product overview and product benefit to the AllProducts and OneProduct view. Currently using random images
  - Added a main page banner and logo to navbar. Hosted locally saved images to Github. Learned a new thing - able to host images on github.
  - Currently stuck with creating a logic to allow dynamic view cart. On first click, it actually creates new cart for user. Subsequent clicks of the Cart button on navbar should direct to view cart.
  - Updated the Database with the DB script to include product overview, benefit and image

 13 April 2024 : Enhancement
 - Manage to incorporate Session into view such that we will be able to pull out CartId we saved using HttpContext.Session in UIController in MVC project. This allows us to utilize the variable to create a condition to check if the cart has already been created or not. If created -> direct to ViewCart View, else -> direct to NewCart View
 - Implemented check if user have created a cart first. If not created, direct to NewCart Method, else ViewCart method. This apply to when move to AllProduct->Oneproduct page and try to add product. Through there, User will see Create Cart First! button instead of Add Product button. Once created, from OneProduct Page will show Add Product Button.
