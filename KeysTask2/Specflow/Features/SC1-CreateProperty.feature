Feature: CreateProperty
	

@mytag
Scenario: Scenario_CreateProperty
	Given I have logged in to application
	And I have entered Property Details
	And I have entered Financial Details
	Then New Property should be created
