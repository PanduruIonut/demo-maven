package demo.maven;
import static org.junit.Assert.*;

import org.junit.Test;
public class DemoTest {
	@Test
	public void shouldReturnTrue(){
		Demo demo= new Demo();	
		assertTrue(demo.getBool());
	}
}
