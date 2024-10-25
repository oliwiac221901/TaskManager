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
- **401 Unauthorized**: Authentication is required, or the provided data is not authorized for the requested operation.
- **409 Conflict**: The provided email or username already exists.

