using StrategyPattern;
using StrategyPattern.Models;
using StrategyPattern.Payments;

var cart = new ShoppingCart();
cart.AddProduct(new Product{ Name = "Apple", Price = 1.99 });
cart.AddProduct(new Product() { Name = "Banana", Price = 2.99 });

var creditCardPayment = new CreditCardPayment("1234 5678 9012 3456", "12/2022", "123");
cart.SetPaymentStrategy(creditCardPayment); 
cart.Checkout();

var payPalPayment = new PayPalPayment("test@test.com", "password");
cart.SetPaymentStrategy(payPalPayment);
cart.Checkout();