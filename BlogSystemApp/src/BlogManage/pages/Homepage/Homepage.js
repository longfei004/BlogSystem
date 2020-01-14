import React from 'react';
import { useEffect, useState } from 'react';
import { getBlogs } from '../../api/BlogApi';
import './Homepage.less';
import BlogList from '../../components/BlogList/BlogList';

const Homepage = () => {
    const [blogs, setBlogs] = useState([]);

    useEffect(() => {
        getBlogs().then(result => {
            if (result !== undefined)
                setBlogs(result);
        });
    }, []);

    return (
        <div className='homepage'>
        { blogs !==[] ? <BlogList blogs={blogs} /> : <p>This is no any blog!</p> }
        <div className='home-side-item'></div>
        </div>
    )
}

export default Homepage;