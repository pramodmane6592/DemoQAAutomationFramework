Feature: AlertsWindows	

@Windows
Scenario: GoTo Windows page and navigate to new tab
	Given I navigate to Demo QA Website	
	Then I click Browser Windows link
	Then I Open new tab and validate
@Windows
Scenario: GoTo Windows page and navigate to new Window
	Given I navigate to Demo QA Website	
	Then I click Browser Windows link
	Then I Open new Window and validate

@Alerts
Scenario: GoTo Windows page and open and Hadle Alert
	Given I navigate to Demo QA Website	
	Then I click Alerts link
	Then I Open new Alert and Accept