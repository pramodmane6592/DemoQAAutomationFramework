Feature: DragAndDrop	

@DragAndDrop
Scenario: Perform Drag And Drop action on Element
	Given I navigate to Demo QA Website	
	Then I click Droppable link
	Then I perform drag and drop action 