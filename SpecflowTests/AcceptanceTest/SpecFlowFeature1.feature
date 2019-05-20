Feature: SpecFlowFeature1
	In order to update my profile 
	As a skill trader
	I want to add the languages that I know

@mytag
Scenario Outline: Check if user could able to add maximum four  languages 
	Given I clicked on the Language tab under Profile page
	When When I add a new "<language>"
	Then that language should be displayed on my listings
 
 Examples: 
         
		 | language |
		 | English  |
		 | Telugu   |
		 
		
		 
	



Scenario: Check if user could able to Update added language 
	Given I clicked on the Language tab under Profile page.
And   I clicked on Edit Symbol.
	When i changed the language in language tab and selected level from dropdown list.
	And  i clicked on Update Button.
	Then that updated language should be displayed in my language tab with new language.
	

	 Scenario:Check if user try's to click on update button by keeping required fields empty
	 Given I clicked on language tab under Profile page.
	 When I leave language tab and level empty and clicked on Update Button.
	 Then I should able to see popup to enter language and level.
	 

	
	 Scenario: Checking if user is able to click on cancel button after clicking update.
	Given when i clicked on the Language tab under Profile page.
	And i updated language tab by selecting edit symbol.
	When  i clicked on Cancel Button.
	Then that language should not updated with new language.


	
	 Scenario: Check if user could able to Click on cross(Delete) Symbol.
	Given I click on the Language tab under Profile page.
	When  I click on delete symbol.
	Then that language should Delete from my Language listing.
	






