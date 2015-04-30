package ListOfInstitutes;

import javax.jws.WebMethod;
import javax.jws.WebService;
import java.util.List;

/**
 * Created by Kirill Maloyaroslavtsev on 30.04.2015.
 */
@WebService
public class ListOfInstitutesWebService {
    @WebMethod
    public List<String> GetInstitutesNames(){
        return XMLReader.getInstitutesNamesList();
    }

    @WebMethod
    public String getDescriptionByName(String instituteName){
        return XMLReader.getDescriptionOfInstitute(instituteName);
    }
}
