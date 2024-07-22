Feature: UpdateUserAccount


  @smoke
  @Update

  Scenario Outline: 4-user could login with valid email and password
    Given user navigates to login page
    And user login with email and password <accountType>
    When the user clicks the login button
    Then user login to the system successfully
    When user navigates to my account page
    And user update gender option
    And user clicks on save button
    Then success pop up displayed


Examples:  
| accountType |
| valid       |