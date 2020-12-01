package com.juliusfinancas.domain.common;

import lombok.Getter;
import lombok.Setter;

import java.time.LocalDateTime;

@Getter
@Setter
public class BaseEntity {

    private String id;

    private LocalDateTime insertDate;

}
