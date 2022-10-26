package com.questionario.selenium.testing;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.Select;
//import org.openqa.selenium.firefox.FirefoxDriver;

public class Tests {
    public static void main(String[] args) {
    	
    	
        WebDriver driver = new ChromeDriver();

        driver.get("http://localhost:3000/");
          WebElement input = driver.findElement(By.id("email"));
          input.sendKeys("rafa@test.com");
          input = driver.findElement(By.id("password"));
          input.sendKeys("1234");
          driver.findElement(By.id("submit")).click();
          String uRL = driver.getCurrentUrl();
          String correctUrl = "localhost:3000/questions";
          if(uRL.equals(correctUrl)) {
        	  System.out.println("correct url");
          }
    	  Select drpDown = new Select(driver.findElement(By.id("select")));
    	  drpDown.selectByVisibleText("perro");
    	  driver.findElement(By.id("send")).click();
    	  drpDown.selectByVisibleText("3");
    	  driver.findElement(By.id("send")).click();
    	  drpDown.selectByVisibleText("true");
    	  driver.findElement(By.id("send")).click();
    	  System.out.println("correct");

 
    }
}
