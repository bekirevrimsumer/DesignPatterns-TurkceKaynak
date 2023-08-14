
using ObserverPattern.Models;

var store = new Store("Amazon");

var product1 = new Product { Name = "iPhone 12", Price = 1000 };
var product2 = new Product { Name = "iPhone 12 Pro", Price = 1200 };

var customer1 = new Customer("John");
var customer2 = new Customer("Mary");
var customer3 = new Customer("Peter");

store.Subscribe(customer1, product1);
store.Subscribe(customer2, product2);
store.Subscribe(customer3, product1);

store.Subscribe(customer1, product2);
store.Unsubscribe(customer1, product1);

store.AddProduct(product1);
store.AddProduct(product2);