Feature: SC2-SearchProperty


@mytag
Scenario: Scenario_SearchProperty
	Given I have logged in to application
	When I have entered search item
	Then the search result should be shown
