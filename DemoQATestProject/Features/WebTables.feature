Feature: WebTables

@WebTables
Scenario: GoTo WebTables page and edit table data
	Given I navigate to Demo QA Website
	Then I click Web Tables link
	When Get Web Tables first row and Edit Info
		| FullName |
		| Pramod   |
	Then I Validate the results post edit
	