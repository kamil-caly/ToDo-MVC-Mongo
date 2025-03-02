# ToDoListMVC-MongoDb

## Description
ToDoListMVC-MongoDb is an ASP.NET Core MVC application for task management using MongoDB.

## Technologies
- **ASP.NET Core MVC**
- **MongoDB**
- **Entity Framework Core**

## Installation

### 1. Clone the repository
```bash
git clone https://github.com/your-repo.git
cd ToDoListMVC-MongoDb
```

### 2. Configure MongoDB
Edit `appsettings.json`:
```json
"MongoDbSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "ToDoDb"
}
```

### 3. Run the application
```bash
dotnet run
```

## API Endpoints
- `GET /ToDo/Index` – List tasks
- `POST /ToDo/Create` – Add a task
- `PUT /ToDo/Toggle/{id}` – Mark task as completed
- `DELETE /ToDo/Delete/{id}` – Delete a task
- `GET /ToDo/Edit/{id}` – Get task details
- `POST /ToDo/Edit` – Update task

## License
This project is open source and available under the [GPL-3.0 License](LICENSE).

