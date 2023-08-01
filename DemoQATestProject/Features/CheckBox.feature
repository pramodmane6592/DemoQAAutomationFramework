Feature: CheckBox

@CheckBox
Scenario: GoTo CheckBox page and select CheckBox and verify
	Given I navigate to Demo QA Website	
	Then I click Check Box link
	Then I select Home check box and validate its selected
