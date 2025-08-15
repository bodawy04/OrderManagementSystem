# Enhanced Order Management System

An **ASP.NET Core Web API** built with **Onion Architecture** for managing customers, orders, products, and invoices.  
The system supports **tiered discounts**, **inventory validation**, **multiple payment methods**, **JWT authentication**, and **role-based access control (RBAC)**.

---

## 📋 Features

- **Customer Management**
  - Register customers and view their order history.
- **Order Processing**
  - Place new orders.
  - Apply **tiered discounts** automatically.
  - Validate product stock before confirming orders.
  - Support multiple payment methods (Credit Card, PayPal, etc.).
- **Product Management**
  - Add, update, and view product details.
- **Invoices**
  - Automatically generated upon successful order creation.
- **Role-Based Access Control**
  - Admin: Manage products, orders, and invoices.
  - Customer: Place and view their own orders.
- **JWT Authentication**
  - Secure API endpoints based on roles.
- **Swagger Documentation**
  - Interactive API documentation for testing.

---

## 🗂️ Technologies Used

- **ASP.NET Core Web API**
- **Entity Framework Core** (In-Memory Database for demo)
- **JWT Authentication**
- **Role-Based Authorization**
- **Swagger / Swashbuckle**

---

## 🏛️ Architecture

The project follows the **Onion Architecture**:

```text
Core/
├── Domain/ # Entity models, exceptions & contracts
├── Services/ # Business logic and specifications implementations & mapping profiles
└── ServiceAbstractions/ # Service interfaces

Infrastructure/
├── Persistence/ # EF Core DbContext , repositories & Infrastructure Service Registerations
└── Presentation/ # API Controllers

Shared/ # Common DTOs

OrderManagementSystem/ # Main Application Program
├── Middlewares/ # Exception Middleware
├── Extensions/ # Web Service & Web Application Registeration
└── Factories/ # API Response Factory

Program.cs # Application entry point
```

## 🔐 Authentication & Roles

- **JWT Authentication** secures the API.
- Roles:
  - `Admin` → Manage products, orders, and invoices.
  - `Customer` → Place orders and view their own orders.

**Login Example:**
```json
POST /api/users/login
{
  "username": "admin",
  "password": "admin123"
}
```

## 📌 API Endpoints

### Customers
| Method | Endpoint | Description | Auth Required | Role |
|--------|----------|-------------|---------------|------|
| GET    | `/api/customers/{id}/orders` | Get orders for a specific customer | ✅ | Admin / Customer (own data) |

### Orders
| Method | Endpoint | Description | Auth Required | Role |
|--------|----------|-------------|---------------|------|
| POST   | `/api/orders` | Create a new order | ✅ | Customer |
| GET    | `/api/orders/{id}` | Get details of a specific order | ✅ | Admin / Customer (own data) |
| GET    | `/api/orders` | Get all orders | ✅ | Admin |
| PUT    | `/api/orders/{id}/status` | Update order status | ✅ | Admin |

### Products
| Method | Endpoint | Description | Auth Required | Role |
|--------|----------|-------------|---------------|------|
| GET    | `/api/products` | Get all products | ❌ | - |
| GET    | `/api/products/{id}` | Get details of a product | ❌ | - |
| POST   | `/api/products` | Add a new product | ✅ | Admin |
| PUT    | `/api/products/{id}` | Update product details | ✅ | Admin |

### Invoices
| Method | Endpoint | Description | Auth Required | Role |
|--------|----------|-------------|---------------|------|
| GET    | `/api/invoices/{id}` | Get details of a specific invoice | ✅ | Admin |
| GET    | `/api/invoices` | Get all invoices | ✅ | Admin |

### Users
| Method | Endpoint | Description | Auth Required | Role |
|--------|----------|-------------|---------------|------|
| POST   | `/api/users/register` | Register a new user | ❌ | - |
| POST   | `/api/users/login` | Authenticate a user and return JWT token | ❌ | - |
