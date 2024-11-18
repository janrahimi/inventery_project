Setup

Create a new C# console application.
Add required classes (InventorySystem, Product, Category, etc.) to the project.
Define Core Classes

Product Class:
Define properties: Id, Name, Category, Price.
Implement methods like UpdatePrice.
Category Class:
Define property Name.
StockItem Class:
Include Product, Quantity, and Location.
Add Inventory Functionality

Inventory Class:
Add methods for:
Adding products (AddProduct).
Getting product location (GetProductLocation).
Adding stock (AddStock).
Removing stock (RemoveStock).
Processing orders (ProcessOrder).
Implement Driver Tracking

Driver Class:
Add properties for Name, Company, TruckNumber, and DateTime.
Log driver details when stock is added or removed.
Order Management

Order Class:
Include Id, Customer, and a list of OrderItem.
OrderItem Class:
Define Product and Quantity.
Customer Management

Customer Class:
Add properties: Id, Name, and Email.
Transaction Tracking

Transaction Class:
Include Product, Quantity, TransactionType, and Date.
Log transactions for every stock addition/removal.
Add Reporting

ReportGenerator Class:
Generate reports for:
Inventory (GenerateInventoryReport).
Low stock items (GenerateLowStockReport).
Transactions (GenerateTransactionReport).
User Management

User Class:
Define properties for Username, Password, and Role.
Role Enum:
Include roles like Admin, Manager, and Employee.
Enhance Console Interaction

Display detailed menus for:
Adding products.
Viewing inventory.
Managing stock.
Processing orders.
Generating reports.
Handle invalid inputs gracefully.
Add Input Validation

Ensure all user inputs (e.g., product IDs, quantities) are validated.
Optional Enhancements

Implement data persistence using a database or file system.
Add multi-user authentication with role-based access control.
Create a graphical user interface (GUI) for better user experience.
