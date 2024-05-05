import "../Css/workZone.css"
import axios from 'axios';
import DirectorWorkZone from './DirectorWorkZone';
import EmployeeWorkZone from './EmployeeWorkZone';
import { useEffect, useState } from "react";

const WorkZone = () => {

    const [typeOfUser, setTypeOfUser] = useState('');

    useEffect(() => {
        const getUserRole = async() => {
            const email = sessionStorage.getItem('userEmail');
            const accessToken = localStorage.getItem('accessToken')
            const response = await axios.request({
                url: "api/Roles/GetUserRole",
                method: 'get',
                withCredentials: true,
                headers: {
                    userLogin: email,
                    Authorization: `Bearer ${accessToken}`,
                },
            });
            sessionStorage.setItem('userRole',response.data);
            setTypeOfUser(response.data);
        }

        const getUserDepartment = async() => {
            const email = sessionStorage.getItem('userEmail');
            const accessToken = localStorage.getItem('accessToken')
            const response = await axios.request({
                url: "api/Department/GetDepartment",
                method: 'get',
                withCredentials: true,
                headers: {
                    userName: email,
                    Authorization: `Bearer ${accessToken}`,
                },
            });
            sessionStorage.setItem('userDepartment', response.data.id);
        }

        getUserRole();
        getUserDepartment();
    }, [])
    return (
        <div className='mainViewWork'>
            {typeOfUser == "Director" ?  <DirectorWorkZone/>: <EmployeeWorkZone/>}
        </div>
    );
};

export default WorkZone;