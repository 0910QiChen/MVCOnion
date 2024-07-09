# MVC Onion Architecture
### 1. EntityFramework 6 Code First Using MVC 5 with N-Tier Architecture
### 2. Four Layers:
   - Presentation Layer (referencing Applicaiton and Domain Layers)
   - Application Layer (referencing Repository Layer)
   - Repository Layer (referencing Domain Layer)
   - Domain Layer
### 3. Create ViewModels in Presentation Layer, Data-Transfer-Objects in Application Layer and DomainModels in Domain Layer
### 4. Create interfaces for Repository Layer in Domain Layer
### 5. Create an DbContext in Repository Layer
### 6. Implement interfaces from Domain Layer in the Repository Layer
### 7. Create Services in Applicaiton Layer
### 8. Create Views and Controllers in Presentaion Layer
