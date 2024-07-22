Feature: F01_Register Feature

@smoke
@Register

  Scenario Outline: 1-user could register with valid data successfully
    Given user navigates to register page
    And the data loaded from candidate saved file
    And the user fills the form fields with data of <accountType>
    When the user clicks the Register button
    Then a message <message> displayed


     Examples:
    | accountType    |                         message                        |
    | valid          |              Your registration completed               |
    | invalidEmail   |           Please enter a valid email address.          |
    | password issue |  The password and confirmation password do not match.  |
