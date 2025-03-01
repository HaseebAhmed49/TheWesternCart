# TheWesternCart 🛒

TheWesternCart is an advanced web application designed to help users discover, purchase, and manage the latest western clothing trends. The application offers a wide range of features including browsing clothing items, managing wishlists, applying discount coupons, user authentication, and much more.

## Features ✨
- **User Authentication and Authorization**: Secure login and registration 🔐
- **Clothing Items Management**: Browse, search, and manage clothing items 👗👖
- **Wishlist Management**: Add items to wishlist and manage them 📝
- **Comments and Reviews**: Add and view comments on clothing items 💬
- **Favorites**: Mark clothing items as favorites and manage them ❤️
- **Likes and Dislikes**: Like or dislike comments 👍👎
- **Order Management**: Create and manage orders 📦
- **Order History**: View order history 📜
- **Payments**: Handle payments and payment intents 💳
- **Notifications**: Notify users about discounts on wishlist items 🔔
- **Photo Management**: Upload and manage photos for clothing items 📸
- **Ratings**: Rate clothing items ⭐

## Project Structure 🗂️

### API
- **Controllers**: Contains API controllers for handling HTTP requests.
- **Errors**: Custom error handling classes.
- **Extensions**: Extension methods for configuring services.
- **Helpers**: Helper classes.
- **Middleware**: Custom middleware for handling requests.
- **Program.cs**: Entry point of the application.
- **appsettings.json**: Configuration settings.

### API.Tests

- **XControllerTests.cs**: Unit tests for the X Controller.

### Application
- **Services**: Contains application-level services and business logic.
- **DTOs**: Data Transfer Objects.
- **Interfaces**: Service interfaces.

### Client.SPA

- **src**: Source code for the Angular Single Page Application.
- **angular.json**: Angular CLI configuration file.
- **package.json**: NPM package configuration file.

### Core
- **Entities**: Core entities of the application.
- **Interfaces**: Repository interfaces.

### Infrastructure
- **Repositories**: Data access layer, contains repository implementations.
- **Context**: Database context.
- **Migrations**: Entity Framework migrations.

### Configuration Files
- **.dockerignore**: Docker ignore file.
- **.gitignore**: Git ignore file.
- **docker-compose.yml**: Docker Compose configuration file.
- **TheWesternCart.sln**: Visual Studio solution file.

## Getting Started 🚀

### Prerequisites 📋
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Node.js](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)

### Installation 🛠️

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/TheWesternCart.git
    cd TheWesternCart
    ```

2. Install backend dependencies:
    ```sh
    cd API
    dotnet restore
    ```

3. Install frontend dependencies:
    ```sh
    cd Client.SPA
    npm install
    ```

### Running the Application ▶️

1. Start the backend server:
    ```sh
    cd API
    dotnet run
    ```

2. Start the frontend server:
    ```sh
    cd Client.SPA
    ng serve
    ```

3. Open your browser and navigate to `http://localhost:4200/`.

### Building the Application 🏗️

1. Build the backend:
    ```sh
    cd API
    dotnet build
    ```

2. Build the frontend:
    ```sh
    cd Client.SPA
    ng build
    ```

### Running Tests 🧪

1. Run backend tests:
    ```sh
    cd API.Tests
    dotnet test
    ```

2. Run frontend tests:
    ```sh
    cd Client.SPA
    ng test
    ```

## Contribution 🤝

Contributions are welcome. Please fork the repository and create a pull request with your changes. Don't forget to update the documentation.

## License 📄

This project is licensed under the MIT License.

---
