Feature: WebTables	

@WebTables
Scenario: GoTo WebTables page and edit table data
	Given I navigate to Demo QA Website	
	Then I click Web Tables link
	When I upload the test file on the application
	