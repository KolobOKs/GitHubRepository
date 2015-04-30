package example;

import javax.jws.WebMethod;
import javax.jws.WebService;
import java.util.List;

/**
 * Created by Masha on 03.05.2015.
 */
@WebService
public class Tutors {
    @WebMethod
    public List<String> TutorsList(){
        return Database.getTeachers();
    }

    @WebMethod
    public String TutorPosition(String tutor){
        return Database.getPosition(tutor);
    }
}
