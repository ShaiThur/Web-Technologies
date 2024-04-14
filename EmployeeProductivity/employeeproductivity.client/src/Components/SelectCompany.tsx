import {useState} from "react";


const SelectCompany = (company_names : string[]) => {

    const names = ["Компания Кости", "Компания Сения", "Компания Айнурчика"]
    const [selectedCompany, setSelectedCompany] = useState(false);
    const my_color = selectedCompany ? '#000000' : '#808080';

    const handleSelectChange = (event) => {
        setSelectedCompany(true);
    }


    return(
        <>
            <select onChange={handleSelectChange} style={{color: my_color}}>
                <option disabled selected value className={"mainOption"}>Choose your company</option>
                {names.map((name) => (
                    <option>{name}</option>
                ))}
            </select>
        </>
    )
}

export default SelectCompany;