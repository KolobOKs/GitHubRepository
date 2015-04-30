package HeadOfDepartmentsWebService;

import javax.jws.WebMethod;
import javax.jws.WebService;
import java.util.List;

/**
 * Created by Shabalina Nika on 01.05.2015.
 */
@WebService
public class HeadOfDepartmentsWebService {
    @WebMethod
    public List<String> GetHeadOfDepartmentsNames(){
        return Model.getHeadOfDepartmentsNames();
    }

    @WebMethod
    public String GetHeadOfDepartmentEmail(String headName){
        return Model.getHeadOfDepartmentEmail(headName);
    }
}
