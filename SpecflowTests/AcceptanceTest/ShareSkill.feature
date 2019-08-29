Feature: ShareSkill
	In order to publish skills in managelisting  
	As a skill trader
	I want to add the Skill that I know

@mytag1
Scenario: Check if user is able to click on ShareSkill button
	Given I have navigated to profilepage 
	When I clicked on ShareSkill Button 
	Then I should navigate to ServiceListing page

@mytag2
Scenario:Check if user is able to Enter text by starting with specialcharacters
Given I clicked on Shareskill button and navigated to servicelisting page
When I enterd text starting with special charcters in Title field 
Then I should able to see error message

@mytag3
Scenario:Check if user gives Null values in Description field
Given I clicked on Shareskill button and navigated to servicelisting page
When I click on description field and leave the description field as empty
Then I should able to see error message

@mytag4
Scenario:Check if user can give some message in description field
Given  I clicked on Shareskill button and navigated to servicelisting page
When I Entered some text in description field
Then I should able to see entered message