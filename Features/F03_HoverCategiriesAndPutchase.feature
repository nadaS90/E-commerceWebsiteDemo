Feature: F05_Hover Feature

@smoke
@purchase

 Scenario Outline: 3-user could hover categories and purchase successfully
     Given user navigates to login page
    And user login with email and password <accountType>
    When the user clicks the login button
    Then user login to the system successfully
    Given user hover categories
    And user filter the products
    Then user select a product to purchse
    When user add product to the cart
    And User navigates to cart and find product
    And the user click on the Check Box
    And the user Click on checkout button
    And User fill All required data

    Examples:  
| accountType |
| valid       |
