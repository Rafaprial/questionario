package com.questionario.selenium;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.jdbc.DataSourceAutoConfiguration;

import com.questionario.selenium.testing.Tests;
import com.questionario.selenium.testing.InstallDriversJava;


@SpringBootApplication(exclude={DataSourceAutoConfiguration.class})
public class SeleniumApplication {

	public static void main(String[] args) {
		InstallDriversJava inst = new InstallDriversJava();
		SpringApplication.run(SeleniumApplication.class, args);
		inst.chromeSession();
		Tests.main(args);

	}

}
