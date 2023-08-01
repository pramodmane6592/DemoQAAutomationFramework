Feature: TextBox	

@TextBox
Scenario: GoTo TextBox page and submit form
	Given I navigate to Demo QA Website	
	Then I click Text Box link
	When I enter form details and submit
	| FullName | Email           | CurrentAddress | PermanentAddress |
	| Pramod   | pramod@test.com | Pune           | Pune             |
	Then I Validate the results post submission