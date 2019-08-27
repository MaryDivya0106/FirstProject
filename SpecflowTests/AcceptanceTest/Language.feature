Feature: LanguageFeature
	In order to update my profile 
	As a skill trader
	I want to add the languages that I know

@test
Scenario Outline: Check if user could able to add maximum four  languages 
	Given I clicked on the Language tab under Profile page
	When When I add a new "<language>"
	Then that language should displayed on my listings
 
 Examples: 
         
		 | language |
		 | Tamil  |
		 | Telugu   |
		 | Hindi    |


	Scenario: Check if user could able to add single languages 
	Given I clicked on Language tab under the Profile page
	When When I add new language
	Then that language should displayed on my listings
 



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

 Scenario: Check if user gives duplicate values.
	Given I click on the Language tab under Profile page.
	When  I click on Add New button.
	And I entered existing language and changed level and clicked on Add button
	Then I should able to see tooltip intimating Duplicated data.

	Scenario: Check if user gives Existing Data.
	Given I clicked on Add New button.
	When I entered existing language and level and clicked on the Add button.
	Then I should able to see tooltip intimating as language Exists.


	Scenario: Check Availability status in profile page.
	Given I click on edit button of the Availabity in Profile page.
	When I clicked on the SelectType dropdown and selected status from dropdown.
	Then I can see availability selected status and Tooltip.

	
	Scenario: Check hours status in profile page.
	Given I click on edit button of hours in Profile page click .
	When I clicked on the SelectType dropdown and selected hours from dropdown.
	Then I should able to see the selected hours and popup.

	Scenario: Check EarnTarget status in profile page.
	Given I click on edit button of EarnTarget in Profile page .
	When I clicked on the SelectType dropdown and selected amount from dropdown.
	Then I should able to see the selected amount and popup.




