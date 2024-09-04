# Test Automation Framework

## Description
This is a simple test automation project which includes:
1.Basic page object model for a login page
2.Test case that verifies successful login
3.Test case that verifies login failure with incorrect credentials  
4.Configuration file to manage test data and environment variables
5.Simple reporting mechanism (Html report)


## Getting Started
To run the tests from this project you need to have 
- Visual Studio 
- access to the application
- test data applicable for the application that you use (valid/invalid username and password)
- Chrome with version 128.0.6613.86 or later

### Prerequisites


### Installation
To run the tests:
1. Populate application Url in appsettings.json file, appropriate test data in 'Users' section
(valid/invalid username and password for login) and browser which you want to use for the run
1. Build the solution
2. In menu below open Test->Test Explorer
3. Click 'Run' for running all tests or right click on the test which you'd like to run
4. For checking test report please check the file 'TestReport.html'

