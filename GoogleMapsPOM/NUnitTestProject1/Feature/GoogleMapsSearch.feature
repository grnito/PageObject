Feature: Google Maps Search
	Check if search functionality works

@google maps
Scenario: Google Maps Search Testing
	Given I navigate to Google Maps
	Given I Accept cookies
	Given Enter "Porto" in the search Box
	When click search
	Then Verify left panel has "Porto" as a headline text
	When Click Directions icon
	Then Verify destination field is "Destination Porto"