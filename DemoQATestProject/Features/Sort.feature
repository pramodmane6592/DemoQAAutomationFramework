Feature: Sort	

@Sortable
Scenario: GoTo Sortable page and sort List
	Given I navigate to Demo QA Website	
	Then I click Sortable link
	Then I sort the existing List Elements