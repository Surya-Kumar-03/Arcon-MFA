## Setup
To get started with the frontend, follow these steps:

1. Navigate to the `front-end` folder:
```
cd front-end
```

2. Install the required dependencies:
```
npm install
```

3. Start the development server:
```
npm start
```

This will start the server on port 3000. You can access the application by opening your browser and visiting `http://localhost:3000`.

To get started with the backend, follow these steps:

1. Navigate to the `back-end` folder:
```
cd back-end
```
2. Run the server:
```
dotnet run
```
This will start the server on port 8000. You can access the backend API by sending requests to `http://localhost:8000`.

If you are a developer and want hot refresh while developing, you can use the following command instead:
```
dotnet watch run
```

## MFA Workflow

1. User enters their username and password.
2. The system checks if the provided credentials are valid.
3. If the credentials are valid, the system evaluates the following factors:
   - Consecutive login failures: If the user has experienced multiple consecutive login failures, the system can trigger an MFA challenge as an additional security measure.
   - Geo-location: The system determines the physical location of the user based on their IP address or other available location data.
   - Geo-velocity: The system calculates the distance between the current login attempt and the previous successful login attempt. If the distance is unusually large, it may indicate a potential security risk.
   - Attempted action: Depending on the sensitivity of the action the user is attempting to perform, the system may require additional verification.
   - Entity type: The system identifies the type of device the user is using (e.g., desktop, mobile, tablet) and adjusts the authentication requirements accordingly.
   - 3rd-party threat intelligence data: The system checks if the user's IP address or other relevant data is associated with any known malicious activity or security threats.
   - Day of week and time of day: The system analyzes the current day and time to identify any unusual login patterns or potential anomalies.
   - Operating system: The system checks the user's operating system to ensure it is up to date and doesn't have any known vulnerabilities.
   - Source IP address: The system evaluates the user's IP address for any suspicious or blacklisted activity.
   - User role: Based on the user's role or privileges, the system may require additional verification for certain actions or sensitive data access.
4. If any of the factors indicate a potential risk or if MFA is required for any other reason, the user is prompted to provide an additional factor for authentication.
5. The system generates and sends an MFA challenge to the user.
6. The user receives the MFA challenge and provides the requested information (e.g., entering the verification code).
7. The system validates the provided MFA factor against the expected value.
8. If the MFA factor is successfully validated, the user is granted access.
9. If the MFA factor is invalid, the user is denied access and may be prompted to try again or can be blocked from further access.
