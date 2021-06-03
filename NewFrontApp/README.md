
This is a ReadMe file for my test.

Here i would like to comment some of the features present on my solution.

1 - Layout

I am not a great (or even good) front end developer.
I can implement solutions that are available for implementation, but i am not fluent in CSS.
You will be able to see that. The layout for the product list is not pretty. But it is functional.

The fist page shows all the products present on the database. It is possible to filter by the product name, typing the name in the intput above the products.
Thispage, still, shows the products filtered by subcategories, wich you can choose on the categories menu.
By clicking on the product you will be transported to a detail page. It shows the product name, description, price and allows you to add the product on your shopping cart.
I did not implement the checkout functionality.

2 - Login

I did not implement Identity (or even hashed the password before saving on the database). The login is plain: email and password.
On the first access, when you do not have a created user, you can sign up.

3 - Admin

I have created a simple page to show all products and all users that were added to database.
On the Products page you can add a new project by clicking on the button on the right top of the page.
Once you have added the product it will appear on the list and on the initial page.
I did not create a page to edit or delete products or users. However, it would be simple, 
once the API already contains the methods PUT and DELETE.
