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

3 April 2024 : Code Cleaning
- Identified certain areas for enhancement consideration
  1. Page display starts with 2 links: AllProducts and CreateCart
      May look to enhance this display
  2. Consider using AutoMapper to map the Model constructs from REST API to MVC. Currently is manual import over. 
