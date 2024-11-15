﻿Feature: ProductPage
	In order to test a deploy
	As a visitor
	I want to check the  Product page is up and running:
		- Home page
		- Product page
		- Event calendar
		- Things to do
		- London tube

@Qa-Smoke
Scenario: Product page is up
	Given I navigate to the product page '/things-to-do/place/403052-radisson-blu-edwardian-grafton-hotel'
	#And I don't see an error code
	Then I should be shown the Main Image

@Preview-Smoke
Scenario: Preview Product page is up
	Given I navigate to the Preview product page '/things-to-do/place/403052-radisson-blu-edwardian-grafton-hotel'
	#And I don't see an error code
	Then I should be shown the Main Image
