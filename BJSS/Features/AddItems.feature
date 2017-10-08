Feature: AddItems

Scenario: As a user I want to successfully buy 2 items
Given I am logged in
When I Quick View an item
And I change the size of the item
And I add that item to my basket
And I continue shopping
And I Quick View a different item
And I add that item to my basket
Then I view the basket
And the items are the correct size
And their prices are correct
And Total Products is the sum of the two items
And Total equals the Total Products + Shipping
And I proceed through checkout to payment

Scenario: As a user I want to review previous orders and add a message
Given I am logged in
And I have bought items
When I view previous orders
And I select an item from my previous order
And I add a comment
Then the comment appears under Messages

Scenario: As a tester I want to be sure I can capture screen-grabs with Selenium
Given I am logged in
And I buy items
When the test fails
Then I can successfully capture a screen-grab

Scenario: As a user I can successfully make a create call to an api
Given something or other
When I make a create call
Then I have successfully created something

Scenario: As a user I can successfully make a read call to an api
Given something or other
When I make a read call
Then I can successfully read stuff

Scenario: As a user I can successfully make an update call to an api
Given something or other
When I make an update call
Then I have successfully updated something

Scenario: As a user I can successfully make a delete call to an api
Given something or other
When I make a delete call
Then I have successfully deleted something
