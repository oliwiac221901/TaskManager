# RESTful API for TaskManage

This is the API documentation for **TaskManage**, a task management application. The API allows for the registration of new users, along with other functionalities to manage tasks. Below are the available endpoints and their usage.

---

## Endpoints

### `POST /api/users/register`

This endpoint is used for registering a new user. It expects data in JSON format in the request body. Upon successful processing, the API will return the appropriate status code and response data.

#### Request Body

The request body must include the user's data in JSON format. The required fields are:

- **username** (string): The username (required).
- **email** (string): The user's email address (required).
- **password** (string): The user's password (required).

**Example**:

```json
{
  "username": "john_doe",
  "email": "john_doe@example.com",
  "password": "securepassword123"
}
```

#### Response

The response will return one of the following status codes based on the outcome of the registration process:

- **201 Created**: The user was successfully created.
- **400 Bad Request**: The request is missing required fields or the provided data is invalid.
- **409 Conflict**: The provided username already exists.

#### Data Validation

This project uses FluentValidation with MediatR Pipeline Behavior for input validation.

##### UserName:
- **NotEmpty**
- **MinimumLength** - 3
- **MaximumLength** - 20
##### Email
- **NotEmpty**
- **EmailAddress**
- **MaximumLength** - 50
##### Password
- **NotEmpty**
- **MinimumLength** - 8
- **MaximumLength** - 20

#### Services

- **PasswordHasher** - HashPassword method

This project uses PBKDF2 (Password-Based Key Derivation Function 2) algorithm to generate a secure hash of user passwords during the registration process.

### `POST /api/users/login`

This endpoint is used for authentication a registered user. It expects data in JSON format in the request body. Upon successful processing, the API will return the appropriate status code and JWT Token.

#### Request Body

The request body must include the user's data in JSON format. The required fields are:

- **username** (string): The username (required).
- **password** (string): The user's password (required).

**Example**:

```json
{
  "username": "john_doe",
  "password": "securepassword123"
}
```

#### Response

The response will return one of the following status codes based on the outcome of the authentication process:

- **200 OK**: The user was successfully authenticated.
- **400 Bad Request**: The request is missing required fields or the provided data is invalid.
- **404 Not Found**: The provided user was not found in database.

#### Data Validation

This project uses FluentValidation with MediatR Pipeline Behavior for input validation.

##### UserName:
- **NotEmpty**
##### Password
- **NotEmpty**

#### Services

- **PasswordHasherService** - VerifyPassword method

This project uses method that verifies whether a plaintext password matches a previously stored hashed password during the authentication process.

- **JwtTokenService**

This service is responsible for generating a JWT token only after successful authentication.

### `POST /api/tasks/taskLists`

This endpoint is used for creating a user's task list. It expects data in JSON format in the request body. Upon successful processing, the API will return the appropriate status code and response data.

#### Request Body

The request body must include the user's data in JSON format. The required fields are:

- **taskListName** (string): The name of the task list (required).

**Example**:

```json
{
  "tasklistName": "shopping_list"
}
```

#### Response

The response will return one of the following status codes based on the outcome of the process:

- **201 Created**: The task list was successfully created.
- **401 Unauthorized**: The user is not authorized to create task list.
- **400 Bad Request**: The request is missing required fields or the provided data is invalid.
- **409 Conflict**: The provided task list already exists.

#### Data Validation

This project uses FluentValidation with MediatR Pipeline Behavior for input validation.

##### TaskListName:
- **NotEmpty**
- **MinimumLength** - 3
- **MaximumLength** - 30

#### Services

- **CurrentUserService**

The service records the ID of the authenticated user in the database when a task list is created.
