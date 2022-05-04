# Public holidays API
## Requirements
1. Docker Engine
2. A Microsoft SQL Server database server 
# Deployment instructions
## To deploy from GitHub repository:
1. Clone the repository.
2. Create an .env file in the root directory. Set the environment variables DB_Password, DB_User, DB_Server. Example:
```
DB_Password="YOURPASSWORD"
DB_User="ad_mediapark"
DB_Server="tcp:public-holidays.database.windows.net,1433"
```
3. Optionally, replace port **8081** with your preffered port to access the application in docker.compose.override.yml.
4. Run ```docker compose up```.
## To deploy from Docker image:
You can deploy the docker image anywhere that supports Docker Engine. For this example we'll be using an Azure Container Instance.
1. Create new container instance.
2. Fill required fields. For image source choose **other registry** and provide image `aruzam/publicholidays:latest`.
3. In the **Advanced** tab, set environment variables for **DB_Password**, **DB_User**, **DB_Server**.
4. Create the instance and you're good to go.
