import React from 'react';

const MyModalView = ({title, description, date}) => {
    return (
        <>
            <div className="modalContent">
                <form action="" className='modalForm'>
                    <input type="text" placeholder='Enter title' value={title}/>
                    <textarea name="description" cols="30" rows="10" placeholder='Enter description' value={description}></textarea>
                    <input type="date" value={date}/>
                </form>
            </div>
        </>
    );
};

export default MyModalView;