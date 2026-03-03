I developed a comprehensive Service-Oriented Architecture (SOA)-based procurement system for TechFix as part of my Service Oriented Computing module . This system automates and digitizes the procurement workflow between a company (TechFix) and its external suppliers, replacing manual processes with real-time, API-driven interactions.*

Core Problem Solved:
The system addresses inefficiencies in manual quotation requests, inconsistent pricing, and limited inventory visibility by providing a centralized platform for automated procurement management.

Key Features & Functionality:

Dual-Role Access Control: Separate, secure portals for Admins and Suppliers with role-specific dashboards.

Supplier Portal:

Manage product catalogs (Add, Update, Delete).

Upload inventory and pricing data in real-time.

Create and manage quotations for TechFix requests.

View and manage incoming orders.

Admin Portal:

Compare pricing across multiple suppliers.

Request quotations for specific products.

Manage supplier details and product listings.

Upload purchase orders and monitor inventory levels.

Oversee all procurement orders and history.

Core Services (SOA): The application is built around independent, interoperable services for Quotation Management, Inventory Control, Order Processing, and Supplier Management, communicating via RESTful APIs.

Technical Implementation:

Backend: ASP.NET C# Web API for building robust and scalable RESTful services.

Database: Microsoft SQL Server (MSSQL) for structured data management of suppliers, products, quotations, and orders.

Architecture: Designed using Service-Oriented Architecture principles to ensure loose coupling, reusability, and maintainability.

Testing: Conducted comprehensive Unit, Integration, and System testing to ensure API reliability and data consistency.

Deployment Strategy: Designed for scalability using Docker containerization with Kubernetes orchestration to manage microservices efficiently and ensure high availability.

Outcome:
The result is a scalable, efficient, and responsive procurement platform that streamlines the supply chain process, reduces manual errors, and provides real-time visibility into inventory and pricing for both TechFix administrators and their suppliers.
