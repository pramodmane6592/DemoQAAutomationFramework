Feature: UploadDownload	

@UploadDownload
Scenario: GoTo UploadDownload page and upload file
	Given I navigate to Demo QA Website	
	Then I click Upload and Download link
	When I upload the test file on the application	
	Then I validate uploaded file path

@UploadDownload
Scenario: GoTo UploadDownload page and download file
	Given I navigate to Demo QA Website	
	Then I click Upload and Download link
	When I download sample file from the application		