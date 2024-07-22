Feature: F02_Login feature


  @smoke
  @login

  Scenario Outline: 2-user could login with valid email and password
    Given user navigates to login page
    And user login with email and password <accountType>
    When the user clicks the login button
    Then user login to the system successfully

Examples:  
| accountType |
| valid       |