Feature: Google Maps Search
	Check if search functionality works

@mytag
Scenario: Google Maps Search Testing
	Given I navigate to Google Maps
	And I Accept cookies
	And Enter "Dublin" in the search Box
	And click search
	And Verify left panel has "Dublin" as a headline text
	When Click Directions icon
	Then Verify destination field is "Destination Dublin, Ireland"