Feature: AddItems

Scenario: my first test
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
