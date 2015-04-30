package example;

import javax.jws.WebMethod;

import java.util.List;

/**
 * Created by NPoguca on 03.05.2015.
 */
@javax.jws.WebService
public class WebService {
    @WebMethod
    public List<String> getAbbrList(){
        return XmlParser.getAbbrList();
    }

    @WebMethod
    public String getFullName(String shortName){
        return XmlParser.getFullName(shortName);
    }
}
