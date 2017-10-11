Feature: ReviewPurchases - as a user I want to be able to review previous orders

Scenario: As a user I want to review previous orders and add a message
Given I am logged in
And I have bought items
When I view previous orders
And I select an item from my previous order
And I add a comment
Then the comment appears under Messages

Scenario: As a tester I want to be sure I can capture screen-grabs with Selenium
Given I am logged in
And I have bought items
When the test fails
Then I can successfully capture a screen-grab
