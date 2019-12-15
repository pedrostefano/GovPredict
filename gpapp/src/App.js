import React, { Component } from "react";
import axios from "axios";

import Header from "./components/Header/Header";
import Filters from "./components/Filters/Filters";
import List from "./components/List/List";
import PaginationTool from "./components/PaginationTool/PaginationTool";

import "./App.css";

class App extends Component {
  state = {
    postsData: {
      posts: []
    },
    pagination:{
      limit: 10,
      offset: 0,
      page:1,
      total: 0
    },
    filterOptions: {
      lists: [],
      socialNetworks: []
    },
    filter: {
      content: "",
      initialDate: new Date(new Date().getFullYear(),new Date().getMonth() , new Date().getDate()-10),
      finalDate: new Date(new Date().getFullYear(),new Date().getMonth() , new Date().getDate()),
      lists: [],
      socialNetworks: []
    }
  };

  componentDidMount() {
    this.getOptions();
    this.getFilteredPosts();
  }
  
  getOptions = () => {
    axios
    .get(`http://localhost:5000/post/options`)
    .then(res => {
      const filterOptions = res.data;
      this.setState({ filterOptions });
    });
  }

  getFilteredPosts = (page=1) => {    
    const size = this.state.pagination.limit;    
    axios
      .post(`http://localhost:5000/post/filter/${page}/${size}`, this.state.filter)
      .then(res => {
        const pagination = {
          ...this.state.pagination,
          offset: res.data.summary.listSize * (res.data.summary.pageIndex-1),
          total: res.data.summary.returnedListSize,
        };
        const postsData = res.data; 
        this.setState({ postsData, pagination });
      });
  };

  handlePaginationLimitChange = e => {
    const { pagination } = this.state;
    pagination.limit = e.target.value;
    this.setState(pagination);
  }

  handlePaginationClick = (_offset, page) => {
    this.getFilteredPosts(page);
  }

  handleChangeContent = e => {
    const { filter } = this.state;
    filter.content = e.target.value;
    this.setState(filter);
  };

  handleInitialDateChange = value => {
    const { filter } = this.state;
    filter.initialDate = value;
    this.setState(filter);
  };

  handleFinalDateChange = value => {
    const { filter } = this.state;
    filter.finalDate = value;
    this.setState(filter);
  };

  handleChangeLists = event => {
    const { filter } = this.state;
    filter.lists = event.target.value;
    this.setState(filter);
  };

  handleChangeSocialNetworks = event => {
    const { filter } = this.state;
    filter.socialNetworks = event.target.value;
    this.setState(filter);
  };

  render() {
    return (
      <div className="App">
        <Header />
        <Filters
          options={this.state.filterOptions}
          filter={this.state.filter}
          click={this.getFilteredPosts}
          getFilteredPosts={this.getFilteredPosts}
          handleChangeContent={this.handleChangeContent}
          handleInitialDateChange={this.handleInitialDateChange}
          handleFinalDateChange={this.handleFinalDateChange}
          handleChangeLists={this.handleChangeLists}
          handleChangeSocialNetworks={this.handleChangeSocialNetworks}
        />
        <PaginationTool 
          limit={this.state.pagination.limit}
          offset={this.state.pagination.offset}
          total={this.state.pagination.total}
          handlePaginationLimitChange={this.handlePaginationLimitChange}
          handlePaginationClick={this.handlePaginationClick}
          />
          
        <List posts={this.state.postsData.posts} />
      </div>
    );
  }
}

export default App;
