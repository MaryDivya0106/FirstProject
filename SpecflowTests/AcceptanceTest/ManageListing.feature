Feature: ManageListing
	In order to publish skills in managelisting  
	As a skill trader
	I want to add the Skill that I know
@mytag
Scenario: Check if user is able to delete skill from managelist
	Given I have clicked on MangeListing Tab in ProfilePage
	When i have clicked on delete skill
	Then that skill should delete from list.
