from selenium import webdriver
from selenium.webdriver.firefox.options import Options
from pyvirtualdisplay import Display

display = Display(visible=0, size=(800, 600))
display.start()
print("Display is running.")

firefox_options = Options()
firefox_options.add_argument("--headless")
firefox_options.add_argument("--disable-gpu")

driver = webdriver.Firefox(executable_path="./geckodriver",options=firefox_options)

driver.get("https://silentwave.cc")
print("singlewave.")

print("Browser is running. Press Enter to close...")
input()

driver.quit()
display.stop()

