Feature: ToolTip	

@ToolTip
Scenario: GoTo ToolTip page and get ToolTip of button
	Given I navigate to Demo QA Website	
	Then I click Tool Tips link
	When I mouse over to the element and get its Tool Tip
	
